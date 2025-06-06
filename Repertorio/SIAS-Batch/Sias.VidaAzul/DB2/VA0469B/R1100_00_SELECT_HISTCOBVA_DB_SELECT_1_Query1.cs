using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO,
            DATA_VENCIMENTO,
            SIT_REGISTRO,
            OCORR_HISTORICO,
            COD_DEVOLUCAO
            INTO :COBHISVI-NUM-TITULO,
            :COBHISVI-DATA-VENCIMENTO,
            :COBHISVI-SIT-REGISTRO,
            :COBHISVI-OCORR-HISTORICO,
            :COBHISVI-COD-DEVOLUCAO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
							,
											DATA_VENCIMENTO
							,
											SIT_REGISTRO
							,
											OCORR_HISTORICO
							,
											COD_DEVOLUCAO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'";

            return query;
        }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string COBHISVI_DATA_VENCIMENTO { get; set; }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string COBHISVI_OCORR_HISTORICO { get; set; }
        public string COBHISVI_COD_DEVOLUCAO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 r1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBHISVI_NUM_TITULO = result[i++].Value?.ToString();
            dta.COBHISVI_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.COBHISVI_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.COBHISVI_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.COBHISVI_COD_DEVOLUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}