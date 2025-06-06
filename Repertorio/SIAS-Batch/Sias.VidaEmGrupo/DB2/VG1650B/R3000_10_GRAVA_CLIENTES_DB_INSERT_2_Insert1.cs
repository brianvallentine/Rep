using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1 : QueryBasis<R3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_EMAIL (
            COD_PESSOA,
            SEQ_EMAIL,
            EMAIL,
            SITUACAO_EMAIL,
            COD_USUARIO,
            TIMESTAMP)
            VALUES(:CLIENTES-COD-CLIENTE,
            1,
            :DCLPESSOA-EMAIL.EMAIL,
            'A' ,
            'VG1650B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_EMAIL ( COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP) VALUES({FieldThreatment(this.CLIENTES_COD_CLIENTE)}, 1, {FieldThreatment(this.EMAIL)}, 'A' , 'VG1650B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string EMAIL { get; set; }

        public static void Execute(R3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1 r3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1)
        {
            var ths = r3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_10_GRAVA_CLIENTES_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}