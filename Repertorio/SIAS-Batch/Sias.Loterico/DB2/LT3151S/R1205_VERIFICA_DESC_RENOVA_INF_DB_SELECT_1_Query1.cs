using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3151S
{
    public class R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1 : QueryBasis<R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(A.QTD_REN_SEM_SINI,0)
            ,VALUE(A.QTD_REN_SEM_SINI_INF,11)
            INTO :WS-EXISTE-DESC-SEM-SINI
            ,:WS-EXISTE-DESC-SEM-SINI-INF
            FROM SEGUROS.LT_MOV_PROPOSTA A
            WHERE A.COD_EXT_SEGURADO = :WS-COD-LOTERICO
            AND A.DT_INIVIG_PROPOSTA BETWEEN
            :WS-DTINIVIG-APOLICE AND
            :WS-DTTERVIG-APOLICE
            AND A.QTD_REN_SEM_SINI_INF IS NOT NULL
            AND A.QTD_REN_SEM_SINI_INF NOT IN (11)
            AND A.SEQ_PROPOSTA =
            (SELECT MAX(B.SEQ_PROPOSTA)
            FROM SEGUROS.LT_MOV_PROPOSTA B
            WHERE B.COD_EXT_SEGURADO = :WS-COD-LOTERICO
            AND B.DT_INIVIG_PROPOSTA BETWEEN
            :WS-DTINIVIG-APOLICE
            AND :WS-DTTERVIG-APOLICE
            AND B.QTD_REN_SEM_SINI_INF IS NOT NULL
            AND B.QTD_REN_SEM_SINI_INF NOT IN (11))
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(A.QTD_REN_SEM_SINI
							,0)
											,VALUE(A.QTD_REN_SEM_SINI_INF
							,11)
											FROM SEGUROS.LT_MOV_PROPOSTA A
											WHERE A.COD_EXT_SEGURADO = '{this.WS_COD_LOTERICO}'
											AND A.DT_INIVIG_PROPOSTA BETWEEN
											'{this.WS_DTINIVIG_APOLICE}' AND
											'{this.WS_DTTERVIG_APOLICE}'
											AND A.QTD_REN_SEM_SINI_INF IS NOT NULL
											AND A.QTD_REN_SEM_SINI_INF NOT IN (11)
											AND A.SEQ_PROPOSTA =
											(SELECT MAX(B.SEQ_PROPOSTA)
											FROM SEGUROS.LT_MOV_PROPOSTA B
											WHERE B.COD_EXT_SEGURADO = '{this.WS_COD_LOTERICO}'
											AND B.DT_INIVIG_PROPOSTA BETWEEN
											'{this.WS_DTINIVIG_APOLICE}'
											AND '{this.WS_DTTERVIG_APOLICE}'
											AND B.QTD_REN_SEM_SINI_INF IS NOT NULL
											AND B.QTD_REN_SEM_SINI_INF NOT IN (11))
											WITH UR";

            return query;
        }
        public string WS_EXISTE_DESC_SEM_SINI { get; set; }
        public string WS_EXISTE_DESC_SEM_SINI_INF { get; set; }
        public string WS_DTINIVIG_APOLICE { get; set; }
        public string WS_DTTERVIG_APOLICE { get; set; }
        public string WS_COD_LOTERICO { get; set; }

        public static R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1 Execute(R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1 r1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1)
        {
            var ths = r1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1205_VERIFICA_DESC_RENOVA_INF_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_EXISTE_DESC_SEM_SINI = result[i++].Value?.ToString();
            dta.WS_EXISTE_DESC_SEM_SINI_INF = result[i++].Value?.ToString();
            return dta;
        }

    }
}