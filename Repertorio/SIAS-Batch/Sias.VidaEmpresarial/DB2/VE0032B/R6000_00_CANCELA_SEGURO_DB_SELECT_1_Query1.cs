using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0032B
{
    public class R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1 : QueryBasis<R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_INCLUSAO,
            COD_AGENCIADOR,
            NUM_ITEM,
            OCORR_HISTORICO,
            NUM_APOLICE,
            COD_SUBGRUPO,
            COD_FONTE,
            SIT_REGISTRO,
            COD_CLIENTE,
            NUM_MATRICULA,
            DATA_INIVIGENCIA
            INTO :SEGURVGA-TIPO-INCLUSAO,
            :SEGURVGA-COD-AGENCIADOR,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-OCORR-HISTORICO,
            :SEGURVGA-NUM-APOLICE,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-COD-FONTE,
            :SEGURVGA-SIT-REGISTRO,
            :SEGURVGA-COD-CLIENTE,
            :SEGURVGA-NUM-MATRICULA,
            :SEGURVGA-DATA-INIVIGENCIA
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_INCLUSAO
							,
											COD_AGENCIADOR
							,
											NUM_ITEM
							,
											OCORR_HISTORICO
							,
											NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											COD_FONTE
							,
											SIT_REGISTRO
							,
											COD_CLIENTE
							,
											NUM_MATRICULA
							,
											DATA_INIVIGENCIA
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.SEGURVGA_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string SEGURVGA_TIPO_INCLUSAO { get; set; }
        public string SEGURVGA_COD_AGENCIADOR { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_COD_FONTE { get; set; }
        public string SEGURVGA_SIT_REGISTRO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_NUM_MATRICULA { get; set; }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string SEGURVGA_NUM_CERTIFICADO { get; set; }

        public static R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1 Execute(R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1 r6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1)
        {
            var ths = r6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_TIPO_INCLUSAO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_AGENCIADOR = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_FONTE = result[i++].Value?.ToString();
            dta.SEGURVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.SEGURVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}