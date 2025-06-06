using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG013
{
    public class P0250_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0250_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT STA_ACOPLADO
            , COD_EMPRESA_CAP
            , QTD_TITULO
            , VLR_TITULO
            , COD_USUARIO
            , SEQ_REMESSA
            , SEQ_REGISTRO
            INTO :VG135-STA-ACOPLADO
            , :VG135-COD-EMPRESA-CAP
            , :VG135-QTD-TITULO
            , :VG135-VLR-TITULO
            , :VG135-COD-USUARIO
            , :VG135-SEQ-REMESSA :WS-NULL-SEQ-REMSSA
            , :VG135-SEQ-REGISTRO :WS-NULL-SEQ-REGISTRO
            FROM SEGUROS.VG_ACOPLADO
            WHERE IDE_SISTEMA = :VG135-IDE-SISTEMA
            AND NUM_CERTIFICADO = :VG135-NUM-CERTIFICADO
            AND COD_PRODUTO = :VG135-COD-PRODUTO
            AND COD_PLANO = :VG135-COD-PLANO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT STA_ACOPLADO
											, COD_EMPRESA_CAP
											, QTD_TITULO
											, VLR_TITULO
											, COD_USUARIO
											, SEQ_REMESSA
											, SEQ_REGISTRO
											FROM SEGUROS.VG_ACOPLADO
											WHERE IDE_SISTEMA = '{this.VG135_IDE_SISTEMA}'
											AND NUM_CERTIFICADO = '{this.VG135_NUM_CERTIFICADO}'
											AND COD_PRODUTO = '{this.VG135_COD_PRODUTO}'
											AND COD_PLANO = '{this.VG135_COD_PLANO}'
											WITH UR";

            return query;
        }
        public string VG135_STA_ACOPLADO { get; set; }
        public string VG135_COD_EMPRESA_CAP { get; set; }
        public string VG135_QTD_TITULO { get; set; }
        public string VG135_VLR_TITULO { get; set; }
        public string VG135_COD_USUARIO { get; set; }
        public string VG135_SEQ_REMESSA { get; set; }
        public string WS_NULL_SEQ_REMSSA { get; set; }
        public string VG135_SEQ_REGISTRO { get; set; }
        public string WS_NULL_SEQ_REGISTRO { get; set; }
        public string VG135_NUM_CERTIFICADO { get; set; }
        public string VG135_IDE_SISTEMA { get; set; }
        public string VG135_COD_PRODUTO { get; set; }
        public string VG135_COD_PLANO { get; set; }

        public static P0250_05_INICIO_DB_SELECT_1_Query1 Execute(P0250_05_INICIO_DB_SELECT_1_Query1 p0250_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0250_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0250_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0250_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG135_STA_ACOPLADO = result[i++].Value?.ToString();
            dta.VG135_COD_EMPRESA_CAP = result[i++].Value?.ToString();
            dta.VG135_QTD_TITULO = result[i++].Value?.ToString();
            dta.VG135_VLR_TITULO = result[i++].Value?.ToString();
            dta.VG135_COD_USUARIO = result[i++].Value?.ToString();
            dta.VG135_SEQ_REMESSA = result[i++].Value?.ToString();
            dta.WS_NULL_SEQ_REMSSA = string.IsNullOrWhiteSpace(dta.VG135_SEQ_REMESSA) ? "-1" : "0";
            dta.VG135_SEQ_REGISTRO = result[i++].Value?.ToString();
            dta.WS_NULL_SEQ_REGISTRO = string.IsNullOrWhiteSpace(dta.VG135_SEQ_REGISTRO) ? "-1" : "0";
            return dta;
        }

    }
}