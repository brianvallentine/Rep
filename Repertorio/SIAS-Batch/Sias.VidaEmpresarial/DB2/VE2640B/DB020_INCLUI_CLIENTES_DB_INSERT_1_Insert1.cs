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
    public class DB020_INCLUI_CLIENTES_DB_INSERT_1_Insert1 : QueryBasis<DB020_INCLUI_CLIENTES_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CLIENTES
            (COD_CLIENTE ,
            NOME_RAZAO ,
            TIPO_PESSOA ,
            CGCCPF ,
            SIT_REGISTRO)
            VALUES
            (:CLIENTES-COD-CLIENTE ,
            :CLIENTES-NOME-RAZAO ,
            :CLIENTES-TIPO-PESSOA ,
            :CLIENTES-CGCCPF ,
            :CLIENTES-SIT-REGISTRO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO) VALUES ({FieldThreatment(this.CLIENTES_COD_CLIENTE)} , {FieldThreatment(this.CLIENTES_NOME_RAZAO)} , {FieldThreatment(this.CLIENTES_TIPO_PESSOA)} , {FieldThreatment(this.CLIENTES_CGCCPF)} , {FieldThreatment(this.CLIENTES_SIT_REGISTRO)})";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_SIT_REGISTRO { get; set; }

        public static void Execute(DB020_INCLUI_CLIENTES_DB_INSERT_1_Insert1 dB020_INCLUI_CLIENTES_DB_INSERT_1_Insert1)
        {
            var ths = dB020_INCLUI_CLIENTES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB020_INCLUI_CLIENTES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}