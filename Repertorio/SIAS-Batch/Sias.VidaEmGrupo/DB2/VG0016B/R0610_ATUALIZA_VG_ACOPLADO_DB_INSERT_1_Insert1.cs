using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0016B
{
    public class R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1 : QueryBasis<R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_ACOPLADO_HIST
            SELECT IDE_SISTEMA
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
            FROM SEGUROS.VG_ACOPLADO
            WHERE IDE_SISTEMA = :VG135-IDE-SISTEMA
            AND NUM_CERTIFICADO = :VG135-NUM-CERTIFICADO
            AND COD_PRODUTO = :VG135-COD-PRODUTO
            AND COD_PLANO = :VG135-COD-PLANO
            AND STA_ACOPLADO = 9
            AND COD_USUARIO = 'VG0016B'
            AND NOM_PROGRAMA = 'INATIVO'
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_ACOPLADO_HIST SELECT IDE_SISTEMA , NUM_CERTIFICADO , COD_PRODUTO , COD_PLANO , DTH_CADASTRAMENTO , DTA_MOVIMENTO , STA_ACOPLADO , COD_EMPRESA_CAP , QTD_TITULO , VLR_TITULO , COD_USUARIO , NOM_PROGRAMA FROM SEGUROS.VG_ACOPLADO WHERE IDE_SISTEMA = {FieldThreatment(this.VG135_IDE_SISTEMA)} AND NUM_CERTIFICADO = {FieldThreatment(this.VG135_NUM_CERTIFICADO)} AND COD_PRODUTO = {FieldThreatment(this.VG135_COD_PRODUTO)} AND COD_PLANO = {FieldThreatment(this.VG135_COD_PLANO)} AND STA_ACOPLADO = 9 AND COD_USUARIO = 'VG0016B' AND NOM_PROGRAMA = 'INATIVO'";

            return query;
        }
        public string VG135_IDE_SISTEMA { get; set; }
        public string VG135_NUM_CERTIFICADO { get; set; }
        public string VG135_COD_PRODUTO { get; set; }
        public string VG135_COD_PLANO { get; set; }

        public static void Execute(R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1 r0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1)
        {
            var ths = r0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}