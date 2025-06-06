using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1_Insert1 : QueryBasis<DB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_ANDAMENTO_PROP
            (
            NUM_CERTIFICADO
            , DTH_CADASTRAMENTO
            , DES_ANDAMENTO
            , COD_USUARIO
            )
            VALUES
            (
            :VG078-NUM-CERTIFICADO
            , CURRENT TIMESTAMP
            , :VG078-DES-ANDAMENTO
            , :VG078-COD-USUARIO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_ANDAMENTO_PROP ( NUM_CERTIFICADO , DTH_CADASTRAMENTO , DES_ANDAMENTO , COD_USUARIO ) VALUES ( {FieldThreatment(this.VG078_NUM_CERTIFICADO)} , CURRENT TIMESTAMP , {FieldThreatment(this.VG078_DES_ANDAMENTO)} , {FieldThreatment(this.VG078_COD_USUARIO)} )";

            return query;
        }
        public string VG078_NUM_CERTIFICADO { get; set; }
        public string VG078_DES_ANDAMENTO { get; set; }
        public string VG078_COD_USUARIO { get; set; }

        public static void Execute(DB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1_Insert1 dB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1_Insert1)
        {
            var ths = dB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB052_INCLUI_VG_ANDAMENTO_PROP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}