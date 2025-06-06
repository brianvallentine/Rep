using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1 : QueryBasis<M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1>
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

        public static void Execute(M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1 m_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1)
        {
            var ths = m_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0600_00_INSERE_ANDAMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}