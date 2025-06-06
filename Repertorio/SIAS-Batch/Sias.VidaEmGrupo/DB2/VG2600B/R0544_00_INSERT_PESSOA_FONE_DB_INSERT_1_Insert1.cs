using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1 : QueryBasis<R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.PESSOA_TELEFONE
            VALUES (:DCLPESSOA.PESSOA-COD-PESSOA ,
            :TIPO-FONE ,
            :SEQ-FONE ,
            :DDI ,
            :DDD ,
            :NUM-FONE ,
            :SITUACAO-FONE ,
            'VG2600B' ,
            CURRENT_TIMESTAMP )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES ({FieldThreatment(this.PESSOA_COD_PESSOA)} , {FieldThreatment(this.TIPO_FONE)} , {FieldThreatment(this.SEQ_FONE)} , {FieldThreatment(this.DDI)} , {FieldThreatment(this.DDD)} , {FieldThreatment(this.NUM_FONE)} , {FieldThreatment(this.SITUACAO_FONE)} , 'VG2600B' , CURRENT_TIMESTAMP )";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string TIPO_FONE { get; set; }
        public string SEQ_FONE { get; set; }
        public string DDI { get; set; }
        public string DDD { get; set; }
        public string NUM_FONE { get; set; }
        public string SITUACAO_FONE { get; set; }

        public static void Execute(R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1 r0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1)
        {
            var ths = r0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0544_00_INSERT_PESSOA_FONE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}