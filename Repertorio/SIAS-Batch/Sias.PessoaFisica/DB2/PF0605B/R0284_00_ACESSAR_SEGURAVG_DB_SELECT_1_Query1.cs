using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DAC_CERTIFICADO,
            NUM_APOLICE,
            COD_SUBGRUPO,
            NUM_ITEM,
            OCORR_HISTORICO,
            DATA_INIVIGENCIA ,
            ( DATA_INIVIGENCIA +
            :DCLPROPOSTA-FIDELIZ.COD-PLANO MONTH )
            INTO :SEGVGAP-DAC-CERTIFICADO,
            :SEGVGAP-NUM-APOLICE,
            :SEGVGAP-COD-SUBGRUPO,
            :SEGVGAP-NUM-ITEM,
            :SEGVGAP-OCORR-HISTORICO,
            :SEGVGAP-DATA-INIVIGENCIA,
            :WDTA-TERVG-CALC
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :SEGVGAP-NUM-CERTIFICADO
            AND TIPO_SEGURADO = :SEGVGAP-TIPO-SEGURADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DAC_CERTIFICADO
							,
											NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											NUM_ITEM
							,
											OCORR_HISTORICO
							,
											DATA_INIVIGENCIA 
							,
											( DATA_INIVIGENCIA +
											{this.COD_PLANO} MONTH )
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.SEGVGAP_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '{this.SEGVGAP_TIPO_SEGURADO}'
											WITH UR";

            return query;
        }
        public string SEGVGAP_DAC_CERTIFICADO { get; set; }
        public string SEGVGAP_NUM_APOLICE { get; set; }
        public string SEGVGAP_COD_SUBGRUPO { get; set; }
        public string SEGVGAP_NUM_ITEM { get; set; }
        public string SEGVGAP_OCORR_HISTORICO { get; set; }
        public string SEGVGAP_DATA_INIVIGENCIA { get; set; }
        public string WDTA_TERVG_CALC { get; set; }
        public string COD_PLANO { get; set; }
        public string SEGVGAP_NUM_CERTIFICADO { get; set; }
        public string SEGVGAP_TIPO_SEGURADO { get; set; }

        public static R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1 Execute(R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1 r0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = r0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGVGAP_DAC_CERTIFICADO = result[i++].Value?.ToString();
            dta.SEGVGAP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGVGAP_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGVGAP_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGVGAP_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WDTA_TERVG_CALC = result[i++].Value?.ToString();
            return dta;
        }

    }
}