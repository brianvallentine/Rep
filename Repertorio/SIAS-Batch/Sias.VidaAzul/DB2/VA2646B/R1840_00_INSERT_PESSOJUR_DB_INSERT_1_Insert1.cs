using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1 : QueryBasis<R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_JURIDICA
            ( COD_PESSOA ,
            CGC ,
            NOME_FANTASIA ,
            COD_USUARIO ,
            TIMESTAMP
            )
            VALUES
            (
            :PESSOA-COD-PESSOA ,
            :CLIENTES-CGCCPF,
            :CLIENTES-NOME-RAZAO,
            :PESSOJUR-COD-USUARIO ,
            CURRENT TIMESTAMP
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_JURIDICA ( COD_PESSOA , CGC , NOME_FANTASIA , COD_USUARIO , TIMESTAMP ) VALUES ( {FieldThreatment(this.PESSOA_COD_PESSOA)} , {FieldThreatment(this.CLIENTES_CGCCPF)}, {FieldThreatment(this.CLIENTES_NOME_RAZAO)}, {FieldThreatment(this.PESSOJUR_COD_USUARIO)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string PESSOJUR_COD_USUARIO { get; set; }

        public static void Execute(R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1 r1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1)
        {
            var ths = r1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1840_00_INSERT_PESSOJUR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}