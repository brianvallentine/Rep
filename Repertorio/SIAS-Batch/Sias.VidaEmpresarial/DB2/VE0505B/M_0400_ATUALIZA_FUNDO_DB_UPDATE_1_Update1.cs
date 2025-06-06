using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0505B
{
    public class M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1 : QueryBasis<M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FUNDOCOMISVA
				SET VLCOMISVG =  '{this.VLCOMISVG}',
				VLCOMISAP =  '{this.VLCOMISAP}',
				PCCOMIND =  '{this.PCCOMIND}',
				PCCOMGER =  '{this.PCCOMGER}',
				PCCOMSUP =  '{this.PCCOMSUP}',
				NUM_APOLICE =  '{this.NUM_APOLICE}',
				COD_SUBGRUPO =  '{this.CODSUBES}',
				NUM_PARCELA =  '{this.V0COMI_NRPARCEL}'
				WHERE  NUM_TERMO =  '{this.NRTERMO}'
				AND CODOPER =  '{this.CODOPER}'";

            return query;
        }
        public string V0COMI_NRPARCEL { get; set; }
        public string NUM_APOLICE { get; set; }
        public string VLCOMISVG { get; set; }
        public string VLCOMISAP { get; set; }
        public string PCCOMIND { get; set; }
        public string PCCOMGER { get; set; }
        public string PCCOMSUP { get; set; }
        public string CODSUBES { get; set; }
        public string NRTERMO { get; set; }
        public string CODOPER { get; set; }

        public static void Execute(M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1 m_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1)
        {
            var ths = m_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0400_ATUALIZA_FUNDO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}