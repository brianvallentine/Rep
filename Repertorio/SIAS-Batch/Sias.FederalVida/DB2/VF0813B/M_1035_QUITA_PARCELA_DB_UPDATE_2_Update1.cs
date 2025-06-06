using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_1035_QUITA_PARCELA_DB_UPDATE_2_Update1 : QueryBasis<M_1035_QUITA_PARCELA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA
				SET SITUACAO = '1' ,
				NSAC =  '{this.V0FTCF_NSAC}',
				CODRET =  '{this.V0HCTA_CODRET}',
				OCORHIST =  '{this.V0HCTA_OCORHISTCOB}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.V0HCTA_NRCERTIF}'
				AND NRPARCEL =  '{this.V0PARC_NRPARCEL}'
				AND OCORRHISTCTA =  '{this.V0HCTA_OCORHISTCTA}'";

            return query;
        }
        public string V0HCTA_OCORHISTCOB { get; set; }
        public string V0HCTA_CODRET { get; set; }
        public string V0FTCF_NSAC { get; set; }
        public string V0HCTA_OCORHISTCTA { get; set; }
        public string V0HCTA_NRCERTIF { get; set; }
        public string V0PARC_NRPARCEL { get; set; }

        public static void Execute(M_1035_QUITA_PARCELA_DB_UPDATE_2_Update1 m_1035_QUITA_PARCELA_DB_UPDATE_2_Update1)
        {
            var ths = m_1035_QUITA_PARCELA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1035_QUITA_PARCELA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}