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
    public class P0200_05_INICIO_DB_INSERT_1_Insert1 : QueryBasis<P0200_05_INICIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_ACOPLADO
            ( IDE_SISTEMA
            , NUM_CERTIFICADO
            , COD_PRODUTO
            , COD_PLANO
            , DTA_MOVIMENTO
            , STA_ACOPLADO
            , COD_EMPRESA_CAP
            , QTD_TITULO
            , VLR_TITULO
            , COD_USUARIO
            , NOM_PROGRAMA
            , DTH_CADASTRAMENTO
            )
            VALUES
            ( :VG135-IDE-SISTEMA
            , :VG135-NUM-CERTIFICADO
            , :VG135-COD-PRODUTO
            , :VG135-COD-PLANO
            , :VG135-DTA-MOVIMENTO
            , :VG135-STA-ACOPLADO
            , :VG135-COD-EMPRESA-CAP
            , :VG135-QTD-TITULO
            , :VG135-VLR-TITULO
            , :VG135-COD-USUARIO
            , :VG135-NOM-PROGRAMA
            , :VG135-DTH-CADASTRAMENTO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_ACOPLADO ( IDE_SISTEMA , NUM_CERTIFICADO , COD_PRODUTO , COD_PLANO , DTA_MOVIMENTO , STA_ACOPLADO , COD_EMPRESA_CAP , QTD_TITULO , VLR_TITULO , COD_USUARIO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.VG135_IDE_SISTEMA)} , {FieldThreatment(this.VG135_NUM_CERTIFICADO)} , {FieldThreatment(this.VG135_COD_PRODUTO)} , {FieldThreatment(this.VG135_COD_PLANO)} , {FieldThreatment(this.VG135_DTA_MOVIMENTO)} , {FieldThreatment(this.VG135_STA_ACOPLADO)} , {FieldThreatment(this.VG135_COD_EMPRESA_CAP)} , {FieldThreatment(this.VG135_QTD_TITULO)} , {FieldThreatment(this.VG135_VLR_TITULO)} , {FieldThreatment(this.VG135_COD_USUARIO)} , {FieldThreatment(this.VG135_NOM_PROGRAMA)} , {FieldThreatment(this.VG135_DTH_CADASTRAMENTO)} )";

            return query;
        }
        public string VG135_IDE_SISTEMA { get; set; }
        public string VG135_NUM_CERTIFICADO { get; set; }
        public string VG135_COD_PRODUTO { get; set; }
        public string VG135_COD_PLANO { get; set; }
        public string VG135_DTA_MOVIMENTO { get; set; }
        public string VG135_STA_ACOPLADO { get; set; }
        public string VG135_COD_EMPRESA_CAP { get; set; }
        public string VG135_QTD_TITULO { get; set; }
        public string VG135_VLR_TITULO { get; set; }
        public string VG135_COD_USUARIO { get; set; }
        public string VG135_NOM_PROGRAMA { get; set; }
        public string VG135_DTH_CADASTRAMENTO { get; set; }

        public static void Execute(P0200_05_INICIO_DB_INSERT_1_Insert1 p0200_05_INICIO_DB_INSERT_1_Insert1)
        {
            var ths = p0200_05_INICIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P0200_05_INICIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}