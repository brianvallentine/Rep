using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1 : QueryBasis<M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.ENDERECOS
            VALUES (:WS-COD-CLI-ATU ,
            2 ,
            :WS-OCC-END-ATU ,
            :BI0005L-S-ENDERECO-R ,
            :BI0005L-S-BAIRRO-R ,
            :BI0005L-S-CIDADE-R ,
            :BI0005L-S-SIGLA-UF-R ,
            :BI0005L-S-CEP-R ,
            :ENDERECO-DDD ,
            :ENDERECO-TELEFONE ,
            :ENDERECO-FAX ,
            :ENDERECO-TELEX ,
            '0' ,
            NULL ,
            NULL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ENDERECOS VALUES ({FieldThreatment(this.WS_COD_CLI_ATU)} , 2 , {FieldThreatment(this.WS_OCC_END_ATU)} , {FieldThreatment(this.BI0005L_S_ENDERECO_R)} , {FieldThreatment(this.BI0005L_S_BAIRRO_R)} , {FieldThreatment(this.BI0005L_S_CIDADE_R)} , {FieldThreatment(this.BI0005L_S_SIGLA_UF_R)} , {FieldThreatment(this.BI0005L_S_CEP_R)} , {FieldThreatment(this.ENDERECO_DDD)} , {FieldThreatment(this.ENDERECO_TELEFONE)} , {FieldThreatment(this.ENDERECO_FAX)} , {FieldThreatment(this.ENDERECO_TELEX)} , '0' , NULL , NULL )";

            return query;
        }
        public string WS_COD_CLI_ATU { get; set; }
        public string WS_OCC_END_ATU { get; set; }
        public string BI0005L_S_ENDERECO_R { get; set; }
        public string BI0005L_S_BAIRRO_R { get; set; }
        public string BI0005L_S_CIDADE_R { get; set; }
        public string BI0005L_S_SIGLA_UF_R { get; set; }
        public string BI0005L_S_CEP_R { get; set; }
        public string ENDERECO_DDD { get; set; }
        public string ENDERECO_TELEFONE { get; set; }
        public string ENDERECO_FAX { get; set; }
        public string ENDERECO_TELEX { get; set; }

        public static void Execute(M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1 m_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1)
        {
            var ths = m_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}