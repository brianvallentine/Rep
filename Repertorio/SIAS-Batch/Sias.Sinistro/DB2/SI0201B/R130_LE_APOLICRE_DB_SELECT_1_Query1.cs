using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0201B
{
    public class R130_LE_APOLICRE_DB_SELECT_1_Query1 : QueryBasis<R130_LE_APOLICRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.PROPRIET,
            B.CGCCPF
            INTO :APOLICRE-PROPRIET,
            :APOLICRE-CGCCPF
            FROM SEGUROS.SINISTRO_CRED_INT A,
            SEGUROS.APOLICE_CREDITO B
            WHERE A.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND B.COD_SUREG = A.COD_SUREG
            AND B.COD_AGENCIA = A.COD_AGENCIA
            AND B.COD_OPERACAO = A.COD_OPERACAO
            AND B.NUM_CONTRATO = A.NUM_CONTRATO
            AND B.CONTRATO_DIGITO = A.CONTRATO_DIGITO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.PROPRIET
							,
											B.CGCCPF
											FROM SEGUROS.SINISTRO_CRED_INT A
							,
											SEGUROS.APOLICE_CREDITO B
											WHERE A.NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND B.COD_SUREG = A.COD_SUREG
											AND B.COD_AGENCIA = A.COD_AGENCIA
											AND B.COD_OPERACAO = A.COD_OPERACAO
											AND B.NUM_CONTRATO = A.NUM_CONTRATO
											AND B.CONTRATO_DIGITO = A.CONTRATO_DIGITO
											WITH UR";

            return query;
        }
        public string APOLICRE_PROPRIET { get; set; }
        public string APOLICRE_CGCCPF { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R130_LE_APOLICRE_DB_SELECT_1_Query1 Execute(R130_LE_APOLICRE_DB_SELECT_1_Query1 r130_LE_APOLICRE_DB_SELECT_1_Query1)
        {
            var ths = r130_LE_APOLICRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R130_LE_APOLICRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R130_LE_APOLICRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICRE_PROPRIET = result[i++].Value?.ToString();
            dta.APOLICRE_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}