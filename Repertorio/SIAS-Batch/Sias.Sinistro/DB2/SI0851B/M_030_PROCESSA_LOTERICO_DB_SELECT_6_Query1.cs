using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0851B
{
    public class M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1 : QueryBasis<M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(A.VAL_OPERACAO),0)
            INTO :V0HIST-VAL-OPERACAO
            FROM SEGUROS.V0HISTSINI H,
            SEGUROS.V0SINI_LOT_ABAT01 A
            WHERE H.NUM_APOL_SINISTRO = :V0MEST-NUM-APOL-SINISTRO
            AND H.OPERACAO IN (1001,1002,1003,1004,1009)
            AND H.SITUACAO <> '2'
            AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND A.OCORHIST = H.OCORHIST
            AND A.COD_RETENCAO = '2'
            AND H.DTMOVTO BETWEEN :V0REL-PERI-INICIAL
            AND :V0REL-PERI-FINAL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(A.VAL_OPERACAO)
							,0)
											FROM SEGUROS.V0HISTSINI H
							,
											SEGUROS.V0SINI_LOT_ABAT01 A
											WHERE H.NUM_APOL_SINISTRO = '{this.V0MEST_NUM_APOL_SINISTRO}'
											AND H.OPERACAO IN (1001
							,1002
							,1003
							,1004
							,1009)
											AND H.SITUACAO <> '2'
											AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND A.OCORHIST = H.OCORHIST
											AND A.COD_RETENCAO = '2'
											AND H.DTMOVTO BETWEEN '{this.V0REL_PERI_INICIAL}'
											AND '{this.V0REL_PERI_FINAL}'";

            return query;
        }
        public string V0HIST_VAL_OPERACAO { get; set; }
        public string V0MEST_NUM_APOL_SINISTRO { get; set; }
        public string V0REL_PERI_INICIAL { get; set; }
        public string V0REL_PERI_FINAL { get; set; }

        public static M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1 Execute(M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1 m_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1)
        {
            var ths = m_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_030_PROCESSA_LOTERICO_DB_SELECT_6_Query1();
            var i = 0;
            dta.V0HIST_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}