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
    public class P0400_05_INICIO_DB_INSERT_1_Insert1 : QueryBasis<P0400_05_INICIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_ACOPLADO_ERRO
            ( IDE_SISTEMA
            , NUM_CERTIFICADO
            , COD_PRODUTO
            , COD_PLANO
            , SEQ_ERRO
            , COD_SQLCODE
            , COD_ERRO
            , DES_ERRO
            , DES_ACAO
            , COD_USUARIO
            , NOM_PROGRAMA
            , DTH_CADASTRAMENTO
            )
            VALUES
            ( :VG139-IDE-SISTEMA
            , :VG139-NUM-CERTIFICADO
            , :VG139-COD-PRODUTO
            , :VG139-COD-PLANO
            , :VG139-SEQ-ERRO
            , :VG139-COD-SQLCODE
            , :VG139-COD-ERRO
            , :VG139-DES-ERRO
            , :VG139-DES-ACAO
            , :VG139-COD-USUARIO
            , :VG139-NOM-PROGRAMA
            , :VG139-DTH-CADASTRAMENTO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_ACOPLADO_ERRO ( IDE_SISTEMA , NUM_CERTIFICADO , COD_PRODUTO , COD_PLANO , SEQ_ERRO , COD_SQLCODE , COD_ERRO , DES_ERRO , DES_ACAO , COD_USUARIO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.VG139_IDE_SISTEMA)} , {FieldThreatment(this.VG139_NUM_CERTIFICADO)} , {FieldThreatment(this.VG139_COD_PRODUTO)} , {FieldThreatment(this.VG139_COD_PLANO)} , {FieldThreatment(this.VG139_SEQ_ERRO)} , {FieldThreatment(this.VG139_COD_SQLCODE)} , {FieldThreatment(this.VG139_COD_ERRO)} , {FieldThreatment(this.VG139_DES_ERRO)} , {FieldThreatment(this.VG139_DES_ACAO)} , {FieldThreatment(this.VG139_COD_USUARIO)} , {FieldThreatment(this.VG139_NOM_PROGRAMA)} , {FieldThreatment(this.VG139_DTH_CADASTRAMENTO)} )";

            return query;
        }
        public string VG139_IDE_SISTEMA { get; set; }
        public string VG139_NUM_CERTIFICADO { get; set; }
        public string VG139_COD_PRODUTO { get; set; }
        public string VG139_COD_PLANO { get; set; }
        public string VG139_SEQ_ERRO { get; set; }
        public string VG139_COD_SQLCODE { get; set; }
        public string VG139_COD_ERRO { get; set; }
        public string VG139_DES_ERRO { get; set; }
        public string VG139_DES_ACAO { get; set; }
        public string VG139_COD_USUARIO { get; set; }
        public string VG139_NOM_PROGRAMA { get; set; }
        public string VG139_DTH_CADASTRAMENTO { get; set; }

        public static void Execute(P0400_05_INICIO_DB_INSERT_1_Insert1 p0400_05_INICIO_DB_INSERT_1_Insert1)
        {
            var ths = p0400_05_INICIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P0400_05_INICIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}