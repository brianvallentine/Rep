using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO,
            COD_CLIENTE,
            DATA_INIVIGENCIA,
            DATA_INIVIGENCIA
            + :PRODUVG-PERI-PAGAMENTO MONTHS,
            COD_SUBGRUPO,
            OCORR_ENDERECO,
            NUM_ITEM,
            OCORR_HISTORICO
            INTO :SEGURVGA-SIT-REGISTRO,
            :SEGURVGA-COD-CLIENTE,
            :SEGURVGA-DATA-INIVIGENCIA,
            :WHOST-DATA-TERVIG-PREMIO,
            :SEGURVGA-COD-SUBGRUPO,
            :SEGURVGA-OCORR-ENDERECO,
            :SEGURVGA-NUM-ITEM,
            :SEGURVGA-OCORR-HISTORICO
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
							,
											COD_CLIENTE
							,
											DATA_INIVIGENCIA
							,
											DATA_INIVIGENCIA
											+ {this.PRODUVG_PERI_PAGAMENTO} MONTHS
							,
											COD_SUBGRUPO
							,
											OCORR_ENDERECO
							,
											NUM_ITEM
							,
											OCORR_HISTORICO
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string SEGURVGA_SIT_REGISTRO { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }
        public string SEGURVGA_DATA_INIVIGENCIA { get; set; }
        public string WHOST_DATA_TERVIG_PREMIO { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }

        public static R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 Execute(R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 r1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = r1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SEGURVGA_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.WHOST_DATA_TERVIG_PREMIO = result[i++].Value?.ToString();
            dta.SEGURVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}