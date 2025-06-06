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
    public class P0300_05_INICIO_DB_INSERT_1_Insert1 : QueryBasis<P0300_05_INICIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_ACOPLADO_HIST
            ( IDE_SISTEMA
            , NUM_CERTIFICADO
            , COD_PRODUTO
            , COD_PLANO
            , DTH_CADASTRAMENTO
            , DTA_MOVIMENTO
            , STA_ACOPLADO
            , COD_EMPRESA_CAP
            , QTD_TITULO
            , VLR_TITULO
            , COD_USUARIO
            , NOM_PROGRAMA
            , SEQ_REMESSA
            , SEQ_REGISTRO
            )
            VALUES
            ( :VG137-IDE-SISTEMA
            , :VG137-NUM-CERTIFICADO
            , :VG137-COD-PRODUTO
            , :VG137-COD-PLANO
            , :VG137-DTH-CADASTRAMENTO
            , :VG137-DTA-MOVIMENTO
            , :VG137-STA-ACOPLADO
            , :VG137-COD-EMPRESA-CAP
            , :VG137-QTD-TITULO
            , :VG137-VLR-TITULO
            , :VG137-COD-USUARIO
            , :VG137-NOM-PROGRAMA
            , :VG137-SEQ-REMESSA :WS-NULL-SEQ-REMSSA
            , :VG137-SEQ-REGISTRO :WS-NULL-SEQ-REGISTRO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_ACOPLADO_HIST ( IDE_SISTEMA , NUM_CERTIFICADO , COD_PRODUTO , COD_PLANO , DTH_CADASTRAMENTO , DTA_MOVIMENTO , STA_ACOPLADO , COD_EMPRESA_CAP , QTD_TITULO , VLR_TITULO , COD_USUARIO , NOM_PROGRAMA , SEQ_REMESSA , SEQ_REGISTRO ) VALUES ( {FieldThreatment(this.VG137_IDE_SISTEMA)} , {FieldThreatment(this.VG137_NUM_CERTIFICADO)} , {FieldThreatment(this.VG137_COD_PRODUTO)} , {FieldThreatment(this.VG137_COD_PLANO)} , {FieldThreatment(this.VG137_DTH_CADASTRAMENTO)} , {FieldThreatment(this.VG137_DTA_MOVIMENTO)} , {FieldThreatment(this.VG137_STA_ACOPLADO)} , {FieldThreatment(this.VG137_COD_EMPRESA_CAP)} , {FieldThreatment(this.VG137_QTD_TITULO)} , {FieldThreatment(this.VG137_VLR_TITULO)} , {FieldThreatment(this.VG137_COD_USUARIO)} , {FieldThreatment(this.VG137_NOM_PROGRAMA)} ,  {FieldThreatment((this.WS_NULL_SEQ_REMSSA?.ToInt() == -1 ? null : this.VG137_SEQ_REMESSA))} ,  {FieldThreatment((this.WS_NULL_SEQ_REGISTRO?.ToInt() == -1 ? null : this.VG137_SEQ_REGISTRO))} )";

            return query;
        }
        public string VG137_IDE_SISTEMA { get; set; }
        public string VG137_NUM_CERTIFICADO { get; set; }
        public string VG137_COD_PRODUTO { get; set; }
        public string VG137_COD_PLANO { get; set; }
        public string VG137_DTH_CADASTRAMENTO { get; set; }
        public string VG137_DTA_MOVIMENTO { get; set; }
        public string VG137_STA_ACOPLADO { get; set; }
        public string VG137_COD_EMPRESA_CAP { get; set; }
        public string VG137_QTD_TITULO { get; set; }
        public string VG137_VLR_TITULO { get; set; }
        public string VG137_COD_USUARIO { get; set; }
        public string VG137_NOM_PROGRAMA { get; set; }
        public string VG137_SEQ_REMESSA { get; set; }
        public string WS_NULL_SEQ_REMSSA { get; set; }
        public string VG137_SEQ_REGISTRO { get; set; }
        public string WS_NULL_SEQ_REGISTRO { get; set; }

        public static void Execute(P0300_05_INICIO_DB_INSERT_1_Insert1 p0300_05_INICIO_DB_INSERT_1_Insert1)
        {
            var ths = p0300_05_INICIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P0300_05_INICIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}