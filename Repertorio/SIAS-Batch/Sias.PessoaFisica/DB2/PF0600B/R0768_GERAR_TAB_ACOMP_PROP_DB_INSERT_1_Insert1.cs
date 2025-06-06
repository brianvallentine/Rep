using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1 : QueryBasis<R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PF_ACOMP_PROPOSTAS VALUES
            (:PROPOFID-NUM-PROPOSTA-SIVPF,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            :PFACOPRO-DTH-INCLUSAO ,
            :PFACOPRO-COD-USUARIO ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PF_ACOMP_PROPOSTAS VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, NULL , NULL , NULL , NULL , {FieldThreatment(this.PFACOPRO_DTH_INCLUSAO)} , {FieldThreatment(this.PFACOPRO_COD_USUARIO)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PFACOPRO_DTH_INCLUSAO { get; set; }
        public string PFACOPRO_COD_USUARIO { get; set; }

        public static void Execute(R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1 r0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1)
        {
            var ths = r0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0768_GERAR_TAB_ACOMP_PROP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}