using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1 : QueryBasis<M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO
            SEGUROS.V0FOLHETO_INFO
            VALUES (:V0FOLH-COD-PRODUTO,
            :V0FOLH-NRCERTIF,
            :V0FOLH-COD-CARTA,
            :V0FOLH-DTEMICAR,
            :V0FOLH-DTSOLICIT,
            :V0FOLH-CODUSU,
            :V0FOLH-SITUACAO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FOLHETO_INFO VALUES ({FieldThreatment(this.V0FOLH_COD_PRODUTO)}, {FieldThreatment(this.V0FOLH_NRCERTIF)}, {FieldThreatment(this.V0FOLH_COD_CARTA)}, {FieldThreatment(this.V0FOLH_DTEMICAR)}, {FieldThreatment(this.V0FOLH_DTSOLICIT)}, {FieldThreatment(this.V0FOLH_CODUSU)}, {FieldThreatment(this.V0FOLH_SITUACAO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0FOLH_COD_PRODUTO { get; set; }
        public string V0FOLH_NRCERTIF { get; set; }
        public string V0FOLH_COD_CARTA { get; set; }
        public string V0FOLH_DTEMICAR { get; set; }
        public string V0FOLH_DTSOLICIT { get; set; }
        public string V0FOLH_CODUSU { get; set; }
        public string V0FOLH_SITUACAO { get; set; }

        public static void Execute(M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1 m_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1)
        {
            var ths = m_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}