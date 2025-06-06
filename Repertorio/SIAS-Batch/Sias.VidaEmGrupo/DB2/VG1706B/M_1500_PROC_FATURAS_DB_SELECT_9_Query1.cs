using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1706B
{
    public class M_1500_PROC_FATURAS_DB_SELECT_9_Query1 : QueryBasis<M_1500_PROC_FATURAS_DB_SELECT_9_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NUM_TITULO ,
            OCORR_HISTORICO
            INTO
            :PARCELAS-NUM-TITULO ,
            :PARCELAS-OCORR-HISTORICO
            FROM
            SEGUROS.PARCELAS
            WHERE
            NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCELAS-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_TITULO 
							,
											OCORR_HISTORICO
											FROM
											SEGUROS.PARCELAS
											WHERE
											NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCELAS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCELAS_NUM_PARCELA}'";

            return query;
        }
        public string PARCELAS_NUM_TITULO { get; set; }
        public string PARCELAS_OCORR_HISTORICO { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }

        public static M_1500_PROC_FATURAS_DB_SELECT_9_Query1 Execute(M_1500_PROC_FATURAS_DB_SELECT_9_Query1 m_1500_PROC_FATURAS_DB_SELECT_9_Query1)
        {
            var ths = m_1500_PROC_FATURAS_DB_SELECT_9_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_PROC_FATURAS_DB_SELECT_9_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_PROC_FATURAS_DB_SELECT_9_Query1();
            var i = 0;
            dta.PARCELAS_NUM_TITULO = result[i++].Value?.ToString();
            dta.PARCELAS_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}