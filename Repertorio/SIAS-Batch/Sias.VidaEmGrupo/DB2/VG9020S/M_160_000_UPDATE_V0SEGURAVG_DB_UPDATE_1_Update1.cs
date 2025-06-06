using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9020S
{
    public class M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1 : QueryBasis<M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0SEGURAVG
				SET OCORR_HISTORICO =  '{this.HOCORR_HISTORICO}',
				COD_AGENCIADOR =  '{this.MCOD_AGENCIADOR}',
				PERI_PAGAMENTO =  '{this.MPERI_PAGAMENTO}',
				PERI_RENOVACAO =  '{this.MPERI_RENOVACAO}',
				FAIXA =  '{this.MFAIXA}',
				TAXA_VG =  '{this.MTAXA_VG}',
				TAXA_AP_MORACID =  '{this.MTAXA_AP_MORACID}',
				TAXA_AP_INVPERM =  '{this.MTAXA_AP_INVPERM}',
				TAXA_AP_AMDS =  '{this.MTAXA_AP_AMDS}',
				TAXA_AP_DH =  '{this.MTAXA_AP_DH}',
				TAXA_AP_DIT =  '{this.MTAXA_AP_DIT}',
				DATA_ADMISSAO =  '{this.SDATA_DTTERVIG}'
				WHERE 
				NUM_CERTIFICADO =  '{this.MNUM_CERTIFICADO}'
				AND TIPO_SEGURADO =  '{this.MTIPO_SEGURADO}'";

            return query;
        }
        public string HOCORR_HISTORICO { get; set; }
        public string MTAXA_AP_MORACID { get; set; }
        public string MTAXA_AP_INVPERM { get; set; }
        public string MCOD_AGENCIADOR { get; set; }
        public string MPERI_PAGAMENTO { get; set; }
        public string MPERI_RENOVACAO { get; set; }
        public string SDATA_DTTERVIG { get; set; }
        public string MTAXA_AP_AMDS { get; set; }
        public string MTAXA_AP_DIT { get; set; }
        public string MTAXA_AP_DH { get; set; }
        public string MTAXA_VG { get; set; }
        public string MFAIXA { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }

        public static void Execute(M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1 m_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1)
        {
            var ths = m_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}